using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GestionListasRestrictivas.Helpers
{

    // Stefan Cruysberghs, http://www.scip.be, March 2008

    /// <summary>
    /// Hierarchy node class which contains a nested collection of hierarchy nodes
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class HierarchyNode<T> where T : class
    {
        public T Entity { get; set; }
        public IEnumerable<HierarchyNode<T>> ChildNodes { get; set; }
        public int Depth { get; set; }
    }

    public static class LinqExtensionMethods
    {
        private static System.Collections.Generic.IEnumerable<HierarchyNode<TEntity>> CreateHierarchy<TEntity, TProperty>
          (IEnumerable<TEntity> allItems, TEntity parentItem,
          Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty, int depth) where TEntity : class
        {
            IEnumerable<TEntity> childs;

            if (parentItem == null)
                childs = allItems.Where(i => parentIdProperty(i).Equals(default(TProperty)));
            else
                childs = allItems.Where(i => parentIdProperty(i).Equals(idProperty(parentItem)));

            if (childs.Count() > 0)
            {
                depth++;

                foreach (var item in childs)
                    yield return new HierarchyNode<TEntity>()
                    {
                        Entity = item,
                        ChildNodes = CreateHierarchy<TEntity, TProperty>
                      (allItems, item, idProperty, parentIdProperty, depth),
                        Depth = depth
                    };
            }
        }

        /// <summary>
        /// LINQ IEnumerable AsHierachy() extension method
        /// </summary>
        /// <typeparam name="TEntity">Entity class</typeparam>
        /// <typeparam name="TProperty">Property of entity class</typeparam>
        /// <param name="allItems">Flat collection of entities</param>
        /// <param name="idProperty">Reference to Id/Key of entity</param>
        /// <param name="parentIdProperty">Reference to parent Id/Key</param>
        /// <returns>Hierarchical structure of entities</returns>
        public static System.Collections.Generic.IEnumerable<HierarchyNode<TEntity>> AsHierarchy<TEntity, TProperty>
          (this IEnumerable<TEntity> allItems, Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty)
          where TEntity : class
        {
            return CreateHierarchy(allItems, default(TEntity), idProperty, parentIdProperty, 0);
        }

        public static IEnumerable<XElement> DescendantsOrEmpty(this XElement element, XName name)
        {
            return element != null
                   ? element.Descendants(name)
                   : Enumerable.Empty<XElement>();
        }

        public static IEnumerable<XElement> ElementExists(this XElement element, XName param)
        {


            if (element.Elements(param).Any() != false)
                return element.Descendants(param);

            return Enumerable.Empty<XElement>();
        }


        public static string SingleElementEmpty(this XElement element, XName param)
        {
            XElement xElement = new XElement(param, "");

            if (element.IsEmpty == false)
                return element.Value;

            return "";
        }


        public static XElement SingleElementExists(this XElement element, XName param)
        {
            XElement xElement = new XElement(param, "");

            if (element.Elements(param).Any() != false)
                return element.Element(param);

            return xElement;
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection properties =
                System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


    }
}
