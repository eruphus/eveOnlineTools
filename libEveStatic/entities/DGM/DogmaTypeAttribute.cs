/*
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

using FluentNHibernate.Mapping;
using libEveStatic.entities.INV;

namespace libEveStatic.entities.DGM
{

    /*
     * 
CREATE TABLE dbo.dgmTypeAttributes
(
  typeID       int,
  attributeID  smallint,
  valueInt     int,
  valueFloat   float,

  CONSTRAINT dgmTypeAttributes_PK PRIMARY KEY CLUSTERED (typeID, attributeID)
)
     * 
     * 
ALTER TABLE dgmTypeAttributes ADD CONSTRAINT dgmTypeAttributes_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE dgmTypeAttributes ADD CONSTRAINT dgmTypeAttributes_FK_attribute FOREIGN KEY (attributeID) REFERENCES dgmAttributeTypes(attributeID)
     * */

    public class DogmaTypeAttributeMapper : ClassMap<DogmaTypeAttribute>
    {
        public DogmaTypeAttributeMapper()
        {
            Table("dgmTypeAttributes");

            CompositeId().KeyReference(x => x.AttributeType, "attributeID").KeyReference(x => x.Type, "typeID");

            References(x => x.AttributeType, "attributeID");
            References(x => x.Type, "typeID");

            Map(x => x.IntValue, "valueInt").Length(50);
            Map(x => x.FloatValue, "valueFloat").Length(200);

        }
    }

    public class DogmaTypeAttribute 
    {

        public virtual DogmaAttributeType AttributeType { get; set; }
        public virtual InventoryType Type { get; set; }

        public virtual int IntValue { get; set; }
        public virtual decimal FloatValue { get; set; }

        public virtual bool Equals(DogmaTypeAttribute other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.AttributeType, AttributeType) && Equals(other.Type, Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DogmaTypeAttribute)) return false;
            return Equals((DogmaTypeAttribute) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((AttributeType != null ? AttributeType.GetHashCode() : 0)*397) ^ (Type != null ? Type.GetHashCode() : 0);
            }
        }
    }
}