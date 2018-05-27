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
    public class JogoController : Controller
    {
        private readonly IJogoBusiness _business;
        private readonly IGeneroBusiness _businessGenero;

        public JogoController(IJogoBusiness business, IGeneroBusiness businessGenero)
        {
            _business = business;
            _businessGenero = businessGenero;
        }

        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<JogoVM>>(_business.RecuperarDapper()));
        }

        public ActionResult Details(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
        }

        public ActionResult Create()
        {
            ViewBag.GeneroCombo = Mapper.Map<IEnumerable<GeneroVM>>(_businessGenero.RecuperarDapper());
            return View();
        }

        [HttpPost]
        public ActionResult Create(JogoVM jogoVM)
        {
            try
            {
                 
                _business.Salvar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
            
        }

        [HttpPost]
        public ActionResult Edit(Guid id, JogoVM jogoVM)
        {
            try
            {
                _business.Alterar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
        }

        [HttpPost]
        public ActionResult Delete(Guid id, JogoVM jogoVM)
        {
            try
            {
                _business.Deletar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel deletar este jogo, verifique se ele não tem emprestimos em aberto.");
                ModelState.AddModelError("", e.Message);
                return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
            }
        }
    }
}
