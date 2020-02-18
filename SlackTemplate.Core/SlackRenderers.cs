using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Core
{
	public class StrongRenderer : IInlineRenderer
	{
		public string Render(XElement element)
		{
			return $"*{element.Value}*";
		}
	}

	public abstract class ImageBlockRenderer<T> : ElementRenderer<T> where T : class
	{
		public class ImageBlock
		{
			public string ImageUrl { get; set; }

			public string AltText { get; set; }

			public string Title { get; set; }

			public string BlockId { get; set; }
		}

		protected ImageBlock ParseElement(XElement element)
		{
			return new ImageBlock()
			{
				ImageUrl	= element.Attribute("image_url")?.Value ?? element.Attribute("src")?.Value,
				AltText		= element.Attribute("alt_text")?.Value ?? element.Attribute("alt")?.Value,
				Title		= element.Attribute("title")?.Value,
				BlockId		= element.Attribute("block_id")?.Value
			};
		}
	}
}
