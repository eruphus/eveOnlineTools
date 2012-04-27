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

namespace eveStatic.entities.INV
{
    /*

CREATE TABLE dbo.invTypeReactions
(
  reactionTypeID  int,
  input           bit,
  typeID          int,
  quantity        smallint,
  --
  CONSTRAINT pk_invTypeReactions PRIMARY KEY CLUSTERED (reactionTypeID, input, typeID)
)

ALTER TABLE invTypeReactions ADD CONSTRAINT invTypeReactions_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)

    */

    public class TypeReactionMapper : ClassMap<TypeReaction>
    {
        public TypeReactionMapper()
        {
            Table("invTypeReactions");

            CompositeId().KeyReference(x => x.Type, "typeID").KeyProperty(x => x.IsInput, "input").KeyProperty(x => x.ReactionTypeId, "reactionTypeID");

            References(x => x.Type, "typeID");

            Map(x => x.IsInput, "input");
            Map(x => x.Quantity, "quantity");
        }
    }


    public class TypeReaction 
    {
        public virtual int ReactionTypeId { get; set; }
        public virtual bool IsInput { get; set; }
        public virtual InventoryType Type { get; set; }

        public virtual short Quantity { get; set; }


        public virtual bool Equals(TypeReaction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ReactionTypeId == ReactionTypeId && other.IsInput.Equals(IsInput) && Equals(other.Type, Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypeReaction)) return false;
            return Equals((TypeReaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ReactionTypeId;
                result = (result*397) ^ IsInput.GetHashCode();
                result = (result*397) ^ (Type != null ? Type.GetHashCode() : 0);
                return result;
            }
        }
    }
}