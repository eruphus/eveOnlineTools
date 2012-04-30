using FluentNHibernate.Mapping;
using libEveStatic.entities.INV;

namespace libEveStatic.entities.RAM
{


    /*

CREATE TABLE dbo.ramAssemblyLineTypeDetailPerCategory
(
  assemblyLineTypeID  tinyint,
  categoryID          int,
  timeMultiplier      float,
  materialMultiplier  float,
  --
  CONSTRAINT ramAssemblyLineTypeDetailPerCategory_PK PRIMARY KEY CLUSTERED (assemblyLineTypeID, categoryID)
)

ALTER TABLE ramAssemblyLineTypeDetailPerCategory ADD CONSTRAINT ramAssemblyLineTypeDetailPerCategory_FK_assemblyLineType FOREIGN KEY (assemblyLineTypeID) REFERENCES ramAssemblyLineTypes(assemblyLineTypeID)
ALTER TABLE ramAssemblyLineTypeDetailPerCategory ADD CONSTRAINT ramAssemblyLineTypeDetailPerCategory_FK_category FOREIGN KEY (categoryID) REFERENCES invCategories(categoryID)


    */

    public class AssemblyLineTypeDetailPerCategoryMapper : ClassMap<AssemblyLineTypeDetailPerCategory>
    {
        public AssemblyLineTypeDetailPerCategoryMapper()
        {
            Table("ramAssemblyLineTypeDetailPerCategory");

            CompositeId().KeyReference(x => x.AssemblyLineType, "assemblyLineTypeID").KeyReference(x => x.Category, "categoryID");

            References(x => x.AssemblyLineType, "assemblyLineTypeID");
            References(x => x.Category, "categoryID");


            Map(x => x.TimeMultipliey, "timeMultiplier");
            Map(x => x.MaterialMultiplier, "materialMultiplier");/*
    Copyright 2012 Alexander Wölfel 
 
    This file is part of eveStatic.

    eveStatic is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    eveStatic is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von eveStatic.

    EveStatic ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */


        }
        
    }


    public class AssemblyLineTypeDetailPerCategory 
    {
        public virtual AssemblyLineType AssemblyLineType { get; set; }
        public virtual InventoryCategory Category { get; set; }

        public virtual decimal TimeMultipliey { get; set; }
        public virtual decimal MaterialMultiplier { get; set; }

        public virtual bool Equals(AssemblyLineTypeDetailPerCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.AssemblyLineType, AssemblyLineType) && Equals(other.Category, Category);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AssemblyLineTypeDetailPerCategory)) return false;
            return Equals((AssemblyLineTypeDetailPerCategory) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((AssemblyLineType != null ? AssemblyLineType.GetHashCode() : 0)*397) ^ (Category != null ? Category.GetHashCode() : 0);
            }
        }
    }
}