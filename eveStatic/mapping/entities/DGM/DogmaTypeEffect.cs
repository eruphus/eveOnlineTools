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
using eveStatic.entities.EVE;
using eveStatic.entities.INV;

namespace eveStatic.entities.DGM
{

    /*
CREATE TABLE dbo.dgmTypeEffects
(
  typeID      int,
  effectID    smallint,
  isDefault   bit,

  CONSTRAINT dgmTypeEffects_PK PRIMARY KEY CLUSTERED(typeID, effectID)
)

     * 
     * 
ALTER TABLE dgmTypeEffects ADD CONSTRAINT dgmTypeEffects_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE dgmTypeEffects ADD CONSTRAINT dgmTypeEffects_FK_effects FOREIGN KEY (effectID) REFERENCES dgmEffects(effectID)

     * 
    */


    public class DogmaTypeEffectMapper : ClassMap<DogmaTypeEffect>
    {
        public DogmaTypeEffectMapper()
        {
            Table("dgmTypeEffects");

            CompositeId().KeyReference(x => x.Type, "typeID").KeyReference(x => x.Effect, "effectID");

            References(x => x.Type, "typeID");
            References(x => x.Effect, "effectID");

            Map(x => x.IsDefault, "isDefault");

        }
    }

    public class DogmaTypeEffect 
    {
        public virtual int Id { get; set; }

        public virtual InventoryType Type { get; set; }
        public virtual DogmaEffect Effect { get; set; }

        public virtual bool IsDefault { get; set; }

        public virtual bool Equals(DogmaTypeEffect other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Effect, Effect);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DogmaTypeEffect)) return false;
            return Equals((DogmaTypeEffect) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0)*397) ^ (Effect != null ? Effect.GetHashCode() : 0);
            }
        }
    }
}