using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Core
{
	public interface IElementRenderer
	{
		object Render(XElement element, object root);
	}

	public abstract class ElementRenderer<T> : IElementRenderer where T : class
	{
		public abstract object Render(XElement element, T root);

		public object Render(XElement element, object root)
		{
			return this.Render(element, (T)root);
		}
	}
}
