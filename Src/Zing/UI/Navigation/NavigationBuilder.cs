﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Zing.UI.Navigation
{
    public class NavigationBuilder
    {
        List<MenuItem> Contained { get; set; }

        public NavigationBuilder()
        {
            Contained = new List<MenuItem>();
        }

        public NavigationBuilder Add(string caption, string position, Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null)
        {
            var childBuilder = new NavigationItemBuilder();

            childBuilder.Caption(caption);
            childBuilder.Position(position);
            itemBuilder(childBuilder);
            Contained.AddRange(childBuilder.Build());

            if (classes != null)
            {
                foreach (var className in classes)
                    childBuilder.AddClass(className);
            }

            return this;
        }

        public NavigationBuilder Add(string caption, Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null)
        {
            return Add(caption, null, itemBuilder, classes);
        }
        public NavigationBuilder Add(Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null)
        {
            return Add(null, null, itemBuilder, classes);
        }
        public NavigationBuilder Add(string caption, string position, IEnumerable<string> classes = null)
        {
            return Add(caption, position, x => { }, classes);
        }
        public NavigationBuilder Add(string caption, IEnumerable<string> classes = null)
        {
            return Add(caption, null, x => { }, classes);
        }

        public NavigationBuilder Remove(MenuItem item)
        {
            Contained.Remove(item);
            return this;
        }

        public NavigationBuilder AddImageSet(string imageSet)
        {
            //_imageSets.Add(imageSet);
            return this;
        }

        public IEnumerable<MenuItem> Build()
        {
            return (Contained ?? Enumerable.Empty<MenuItem>()).ToList();
        }

        //public IEnumerable<string> BuildImageSets()
        //{
        //    return _imageSets.Distinct();
        //}
    }
}