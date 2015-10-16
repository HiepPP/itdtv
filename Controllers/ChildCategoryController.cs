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
    public class ChildCategoryController : Controller
    {
        //
        // GET: /ChildCategory/
        private readonly IChildCategoryService _iService = new ChildCategoryService();
        private readonly INewsService _iNewsService = new NewsService();
        private readonly SeoNameService _seonameService = new SeoNameService();
        readonly int _rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());

        [Route("ChildCategory"), Route("ChildCategory/Index")]
        public ActionResult Index(int page = 1)
        {
            var data = new ChildCategoryViewModel
            {
                ListShow = _iService.GetList(page, _rowsdisplay),
                TotalRecord = _iService.TotalRecord()
            };
            return View(data);
        }


        [Route("ChildCategory/Credit"), Route("ChildCategory/Credit/{id}")]
        public ActionResult Credit(Guid? id)
        {
            if (id.IsNull())
                return View(new ChildCategory { Position = _iService.GetPosition() });
            var result = _iService.GetEntityById(id.GetValueOrDefault());
            return View(result);
        }

        [Route("ChildCategory/Credit"), Route("ChildCategory/Credit/{id}")]
        [HttpPost]
        public ActionResult Credit(ChildCategory model)
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

        [Route("ChildCategory/Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _iNewsService.GetListNewsByChildCategories(id);
            if (result.Any())
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

        [Route("ChildCategory/Active/{id}")]
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

        [Route("ChildCategory/Disable/{id}")]
        public ActionResult Disable(Guid id)
        {
            var dtoList = new List<News>();
            var resultnews = _iNewsService.GetListNewsByChildCategories(id);
            foreach (var item in resultnews)
            {
                item.IsActive = false;
                dtoList.Add(item);
            }

            if (_iNewsService.Update(dtoList))
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