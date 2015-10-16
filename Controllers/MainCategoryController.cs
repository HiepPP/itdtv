using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ssc.consulting.switchboard.Infactractures;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Services;
using ssc.consulting.switchboard.ViewModels;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("Admin")]
    public class MainCategoryController : Controller
    {
        //
        // GET: /MainCategory/
        private readonly IMainCategoryService _iService = new MainCategoryService();
        private readonly INewsService _iNewsService = new NewsService();
        private readonly SeoNameService _seonameService = new SeoNameService();
        readonly int _rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());
        
        [Route("MainCategory"), Route("MainCategory/Index")]
        public ActionResult Index(int page = 1)
        {
            var data = new MainCategoryViewModel
            {
                ListShow = _iService.GetList(page, _rowsdisplay),
                TotalRecord = _iService.TotalRecord()
            };
            return View(data);
        }


        [Route("MainCategory/Credit"), Route("MainCategory/Credit/{id}")]
        public ActionResult Credit(Guid? id)
        {
            if (id.IsNull())
                return View(new MainCategory { Position = _iService.GetPosition() });
            var result = _iService.GetEntityById(id.GetValueOrDefault());
            return View(result);
        }

        [Route("MainCategory/Credit"), Route("MainCategory/Credit/{id}")]
        [HttpPost]
        public ActionResult Credit(MainCategory model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            if (model.Id.IsGuidEmpty())
            {
                if (_iService.IsExitsPosition(model.Position))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.PositionExist + _iService.GetPosition());
                    return View(model);
                }

                if (_seonameService.CheckSeoName(model.SeoName))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.SeoNameExist);
                    return View(model);
                }
                

                if (_iService.Add(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
            }
            else
            {
                var old = _iService.GetEntityById(model.Id);
                if (old.Position != model.Position && _iService.IsExitsPosition(model.Position))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.PositionExist + _iService.GetPosition());
                    return View(model);
                }

                if (old.SeoName != model.SeoName && _seonameService.CheckSeoName(model.SeoName))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.SeoNameExist);
                    return View(model);
                }
                
                if (_iService.Update(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                }
            }


            return RedirectToAction("Index");
        }

        [Route("MainCategory/Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _iNewsService.GetListNewsByMainCategories(id);
            if(result.Any())
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.DeleteNonSuccess);
            }
            else
            {
                if (_iService.Delete(id))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.DeleteSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.DeleteNonSuccess);
                }
            }
            
            return RedirectToAction("Index");
        }

        [Route("MainCategory/Active/{id}")]
        public ActionResult Active(Guid id)
        {
            if (_iService.Active(id))
            {
                SessionUserHelper.CreateSessionSuccess(ConstantStrings.UpdateStatusSuccess);
            }
            else
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.UpdateStatusNonSuccess);
            }
            return RedirectToAction("Index");
        }

        [Route("MainCategory/Disable/{id}")]
        public ActionResult Disable(Guid id)
        {
            var dtoList = new List<News>();
            var resultnews = _iNewsService.GetListNewsByMainCategories(id);
            foreach(var item in resultnews)
            {
                item.IsActive = false;
                dtoList.Add(item);
            }

            if(_iNewsService.Update(dtoList))
            {
                if (_iService.Disable(id))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.UpdateStatusSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.UpdateStatusNonSuccess);
                }
            }
            else
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.UpdateStatusNonSuccess);
            }

            
            return RedirectToAction("Index");
        }
	}
}