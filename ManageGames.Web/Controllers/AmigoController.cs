using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using ManageGames.Business.IBusiness;
using ManageGames.Domain.Entities;
using ManageGames.Web.Models;
using Microsoft.AspNet.Identity.Owin;

namespace ManageGames.Web.Controllers
{
    [Authorize]
    public class AmigoController : Controller
    {
        private readonly IAmigoBusiness _business;
        private ApplicationUserManager _userManager;
        public AmigoController(ApplicationUserManager userManager, IAmigoBusiness business)
        {
            UserManager = userManager;
            _business = business;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<AmigoVM>>(_business.RecuperarDapper()).Where(x => !x.Email.ToUpper().Equals(User.Identity.Name.ToUpper())));
        }

        public ActionResult Details(Guid id)
        {
            return View(Mapper.Map<AmigoVM>(_business.Recuperar(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AmigoVM amigoVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(amigoVM);
                }
                var user = new ApplicationUser { UserName = amigoVM.Email, Email = amigoVM.Email };
                var senhaPadrao = WebConfigurationManager.AppSettings["SenhaPadrao"];
                var result = await UserManager.CreateAsync(user, senhaPadrao);
                if (result.Succeeded)
                    _business.Salvar(Mapper.Map<Amigo>(amigoVM));
                else
                {
                    if (result.Errors.First().Contains("already taken"))
                        ModelState.AddModelError("", "Email já esta sendo usado.");
                    else
                        ModelState.AddModelError("", result.Errors.First());

                    return View(amigoVM);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(amigoVM);
            }

        }

        public ActionResult Edit(Guid id)
        {
            return View(Mapper.Map<AmigoVM>(_business.Recuperar(id)));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, AmigoVM amigoVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(amigoVM);
                }

                _business.Alterar(Mapper.Map<Amigo>(amigoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel alterar este amigo");
                ModelState.AddModelError("", e.Message);
                return View(amigoVM);
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<AmigoVM>(_business.Recuperar(id)));
        }

        [HttpPost]
        public ActionResult Delete(Guid id, AmigoVM amigoVM)
        {
            try
            {
                _business.Deletar(Mapper.Map<Amigo>(amigoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel deletar este amigo, verifique se ele não tem emprestimos em aberto.");
                ModelState.AddModelError("", e.Message);
                return View(Mapper.Map<AmigoVM>(_business.Recuperar(id)));
            }
        }
    }
}
