﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewsComponents.Comment
{
    public class _CommentList: ViewComponent
    {

        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.TGetDestinationById(id);
            return View(values);
        }
    }
}
