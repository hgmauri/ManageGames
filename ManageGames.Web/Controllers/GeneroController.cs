using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ManageGames.Business.IBusiness;
using ManageGames.Domain.Entities;
using ManageGames.Web.Models;

namespace ManageGames.Web.Controllers
{
    [Authorize]
    public class GeneroController : Controller
    {
        private readonly IGeneroBusiness _business;

        public GeneroController(IGeneroBusiness business)
        {
            _business = business;
        }
        
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<GeneroVM>>(_business.RecuperarDapper()));
        }

        public ActionResult Details(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneroVM generoVM)
        {
            try
            {
                _business.Salvar(Mapper.Map<Genero>(generoVM));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, GeneroVM collection)
        {
            try
            {
                _business.Alterar(Mapper.Map<Genero>(collection));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(collection);
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        [HttpPost]
        public ActionResult Delete(Guid id, GeneroVM collection)
        {
            try
            {
                _business.Deletar(Mapper.Map<Genero>(collection));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
    }
}
