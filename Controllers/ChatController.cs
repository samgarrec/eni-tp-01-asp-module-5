using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class ChatController : Controller
    {
        public object Data { get; private set; }

        // GET: Chat
        public ActionResult Index()
        {
            var groupingCat = ChatData.Instance.ListeChat;
           
            ;//Data.Instance.ListeChat;
            return View(groupingCat);
        }
        //            IGrouping<Auteur,Livre> auteurQ2 = Data.Instance.ListeLivres


        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var groupingCat = ChatData.Instance.ListeChat;

            var chat = groupingCat.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
                ViewBag.message = "pas de chat ayant cet id";
            }

            return View(chat);
        }
    


       
     

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chat = ChatData.Instance.ListeChat.FirstOrDefault(c => c.Id == id);



            if (chat == null)

            {

                return RedirectToRoute("/Index");

            }

            else

            {

                return View(chat);

            }
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chat = ChatData.Instance.ListeChat.FirstOrDefault(x => x.Id == id);

                ChatData.Instance.ListeChat.Remove(chat);



                return RedirectToAction("Index");
                // TODO: Add delete logic here

            }
            catch
            {
                return View();
            }
        }
    }
}
