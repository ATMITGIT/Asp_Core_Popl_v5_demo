using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MimeKit;
using WebApplication21.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication21.Controllers
{
	public class UserController : Controller
	{
        private ApplicationContext db;
        public User ForgoutPasswordUser = null;

        public UserController(ApplicationContext context)
        {
            
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name, string Email, string Password,int PeopleId)
        {
           
                User user = new User { Name = Name, Email = Email, Password = Password,Link = PeopleId };
           // Image image = new Image { ImageLink = "~/images/tiktok.jpg", UserName = "Lyosha" };
           
            db.Users.Add(user);
            //db.Images.Add(image);
                db.SaveChanges();
            // ViewBag.name = image.UserName;

            User user2 = db.Users.FirstOrDefault(x => x.Email == Email);

            ViewBag.K = user2.Id;

            return RedirectPermanent("~/User/" + user.Link);
            

        }

        [Route("api/ajax/news")]
        public string newAjax(string imagelink)
		{
            Image image = db.Images.FirstOrDefault(x => x.ImageSrc == imagelink);
            db.Images.Remove(image);
            db.SaveChanges();


            return "ok";

        }

        [Route("api/ajax/api")]
        //[Route("User/{PeopleId?}")]
        public List<string> getAjax(string imagelink,string username,int Id)
        {//avelacnel databaseum
            /* Image image = new Image { ImageLink = imagelink, UserName = username };
             db.Images.Add(image);
             db.SaveChanges();*/
            //ViewBag.name = db.Images.ToList();
            // List<Image> ImageList = db.Images.Where(x => x.Id == x.).ToList();

            // user = db.Images.Where(x => x.UserId == id);
            //User user = db.Users.FirstOrDefault(x => x.Id == Id);
            // user.ProfImage = imagelink;
            Image m = new Image { ImageSrc = imagelink, ImageText = username, UserId = Id };
            bool done = db.Images.Any(x => x.ImageSrc == imagelink);

			if (done)
			{

			}
			else
			{
                db.Add(m);
                db.SaveChanges();
               
            }

           

            List<Image> list = db.Images.Where(x => x.UserId == Id).ToList();

            List<string> ListStr = new List<string>();

            foreach(var p in list)
			{
                if(p.ImageSrc != null)
				{
                    ListStr.Add(p.ImageSrc);
                }
               
			}
            ViewBag.list = ListStr;

            return ListStr;
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
         

            bool LoginUser = db.Users.Any(x => x.Email == Email && x.Password == Password);
            ViewBag.email = Email;

            if (LoginUser)
            {
                User user = db.Users.FirstOrDefault(x => x.Password == Password);
              

              
                return RedirectPermanent("~/User/" + user.Link);
            }
            else

            {
                return RedirectPermanent("~/User/Login");
            }



        }

        [Route("User/{PeopleId?}")]
        public IActionResult UserPage(int PeopleId)
        {
            User user = db.Users.FirstOrDefault(x => x.Link== PeopleId);
            
            ViewData["id"] = user.Id;

            List<Image> list = db.Images.Where(x => x.UserId == user.Id).ToList();
            ViewData["list"] = list;

            return View();
        }

        public IActionResult ProfileSettings()
        {
            return View();
        }


        public IActionResult ProfileSettingsChange()
        {
            return View();
        }
        public IActionResult SettingsChange2()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPasswordUser(string Password,string ConfirmPassword,int SixCode)
		{
         
        User user2 = db.Users.FirstOrDefault(x => x.NewGuidUser == SixCode);
           
                if(Password == ConfirmPassword && user2!=null)
             {
                 user2.Password = Password;
                 db.Users.Update(user2);
                 db.SaveChanges();
             }
             else
             {
                // ViewBag.ForgoutPasswordUser = "Пароли не совподают";
             }


            //ViewBag.ob1 = ForgoutPasswordUser.Email;
            //ViewBag.ob2 = ForgoutPasswordUser.Password;
            return View();
		}

        [HttpGet]
        public IActionResult ForgotPasswordUser()
		{

            return View();
            
		}

       [HttpPost]
        public IActionResult ForgotPassword(string ForgotEmail)
        {
            User user = db.Users.FirstOrDefault(x => x.Email == ForgotEmail);
			
            Random generator = new Random();
            int r = generator.Next(100000, 999999);
            user.NewGuidUser = r;

            db.Users.Update(user);
            db.SaveChanges();


            //ForgoutPasswordUser = db.Users.FirstOrDefault(x => x.Email == ForgotEmail);


            MailAddress from = new MailAddress("peopltest@gmail.com", "PeoplTeam");
          
            MailAddress to = new MailAddress(ForgotEmail);
        
            MailMessage m = new MailMessage(from, to);
          
            m.Subject = $"Здраствуйте {user.Name}! Вы получили шестиричный клю чтобы восстоновить пароль";
            
            m.Body = $"<div>ваш код - {user.NewGuidUser}</div>";

            m.IsBodyHtml = true;
          
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
           
            smtp.Credentials = new NetworkCredential("peopltest@gmail.com", "peopltest12345");
            smtp.EnableSsl = true;
            smtp.Send(m);
           

            return View("SixCodeConfirm");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
           
               
                    return View();
            
            
            
        }

        [HttpPost]
        public IActionResult ChangePassword(int Link , string NewPassword,string NewPasswordConfirm)
        {
            User user = db.Users.FirstOrDefault(x => x.Link == Link);
            
            db.Users.Update(user);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult SixCodeConfirm()
		{
            return View();
		}

        [HttpPost]
        public IActionResult SixCodeConfirm(int SixCode)
        {
            User user3 = db.Users.FirstOrDefault(x => x.NewGuidUser == SixCode);
            ViewBag.Code = SixCode;
           if(user3 != null){
              //  user3.Done = true;
                return View("ForgotPasswordUser");
			}

            return View();
        }




    }
}

