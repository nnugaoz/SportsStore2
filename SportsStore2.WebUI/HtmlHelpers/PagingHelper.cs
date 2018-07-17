﻿using SportsStore2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString Paging(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> func)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.PageCount; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", func(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}