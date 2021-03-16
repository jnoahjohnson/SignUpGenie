using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        [ViewContext]
        [HtmlAttributeName]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageInfo { get; set; } /*add in paginginfo class*/
        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            _urlHelperFactory = hp;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for(int rep = 1; rep <=PageInfo.TotalPages; rep++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = rep;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);

                    if (rep == PageInfo.CurrentPage)
                        tag.AddCssClass(PageClassSelected);
                    else
                        tag.AddCssClass(PageClassNormal);
                }
                tag.InnerHtml.Append(rep.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
