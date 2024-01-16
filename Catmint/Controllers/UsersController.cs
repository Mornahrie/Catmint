using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catmint.Data;
using Catmint.Models;
using System.ComponentModel;

namespace Catmint.Controllers
{
    public class UsersController : Controller
    {
        int user_id = Get.Value; //для редактирования Edit

        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AcceptVerbs("Get", "Post")] //если меньше 14 лет
        public async Task<IActionResult> CheckDate(DateTime date_of_birth)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.date_of_birth == date_of_birth);
            bool isAfter14 = true;
            if(DateTime.Today.Year - date_of_birth.Year < 14)
                isAfter14 = false;
            return Json(isAfter14);
        }

        [AcceptVerbs("Get", "Post")] //если почта уже существует
        public async Task<IActionResult> CheckEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.email == email);
            //await Console.Out.WriteLineAsync($"user_id = {user_id}, user.user_id = {user.user_id}");
            bool isEmailUnique = (user == null || user.user_id == user_id);
            return Json(isEmailUnique);
        }
        [AcceptVerbs("Get", "Post")] //если логин уже существует
        public async Task<IActionResult> CheckLogin(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.login == login);
            bool isLoginUnique = (user == null || user.user_id == user_id || Get.forLogIn == 1);
            return Json(isLoginUnique);
        }

        [AcceptVerbs("Get", "Post")] //если телефон уже существует
        public async Task<IActionResult> CheckPhone(string phone_num)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.phone_num == phone_num);
            bool isPhoneUnique = (user == null || user.user_id == user_id);
            return Json(isPhoneUnique);
        }

        [AcceptVerbs("Get", "Post")] //если пароль уже существует
        public async Task<IActionResult> CheckPass(string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.password == password);
            bool isPassUnique = (user == null || user.user_id == user_id || Get.forLogIn == 1);
            return Json(isPassUnique);
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (Get.LoggedIn == 1) //если уже осуществлен вход в акк
            {
                var ul = await _context.Users.FirstOrDefaultAsync(u => u.user_id == Get.ID);
                id = ul.user_id;
            }

            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //// GET: Users/ToLogin check
        public async Task<IActionResult> ToLoginCheck(string login, string password) //проверка логина и пароля
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.login == login);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Неверный логин или пароль.");
                return View("ToLogin"); // Перенаправление на страницу входа с сообщением об ошибке
            }

            bool isPasswordCorrect = (password == user.password);
            if (!isPasswordCorrect)
            {
                ModelState.AddModelError(string.Empty, "Неверный логин или пароль.");
                return View("ToLogin"); // Перенаправление на страницу входа с сообщением об ошибке
            }


            Get.LoggedIn = 1;
            Get.ID = user.user_id; //для просмотра акка
            // Аутентификация пользователя 
            Get.Privelege = user.right_id; 
            if (Get.Privelege == 1)
            {
                return RedirectToAction("Index", "Main");
            }
            return View("Details", await _context.Users.FirstOrDefaultAsync(m => m.login == login));//если обычный юзер

        }
        public IActionResult ToLogOut()//выход из аккаунта
        {
            Get.forLogIn = 0; //для отключения исключ при входе 
            Get.LoggedIn = 0; //статус - выход из аккаунта
            Get.Privelege = 0; //статус права тоже обнуляем
            Get.ID = 0;

            return RedirectToAction("Index", "Main");
        }
        public IActionResult ToLogin()//для кнопки входа
        {
            return View();
        }

        // GET: Users/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]      
        public async Task<IActionResult> Create([Bind("user_id,right_id,sex_id,cat_id,name,surname,fathername,date_of_birth,phone_num,email,login,password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_id,right_id,sex_id,cat_id,name,surname,fathername,date_of_birth,phone_num,email,login,password,sol")] User user)
        {
            if (id != user.user_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.user_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();

            Get.forLogIn = 0;
            Get.LoggedIn = 0; //как бы акка больше нет
            return RedirectToAction("Index", "Main"); 
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.user_id == id)).GetValueOrDefault();
        }
    }
}