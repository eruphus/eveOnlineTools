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

using System;
using System.Linq.Expressions;
using FluentNHibernate.Mapping;
using libEveStatic.types;

namespace libEveStatic.mappers
{
    public class ClassMapper<T> : ClassMap<T>
    {

        protected void MapLocation<TComponent>(Expression<Func<T, TComponent>> redir, string xColumnName, string yColumnName, string zColumnName) where TComponent : Location
        {
            Component(redir, m =>
            {
                m.Map(x => x.X, xColumnName).Access.BackingField();
                m.Map(x => x.Y, yColumnName).Access.BackingField();
                m.Map(x => x.Z, zColumnName).Access.BackingField();
            });
        }

    }

    public class SubclassMapper<T> : SubclassMap<T>
    {

        protected void MapLocation<TComponent>(Expression<Func<T,TComponent>> redir , string xColumnName, string yColumnName, string zColumnName) where TComponent : Location
        {
            Component(redir, m =>
                                 {  
                                     m.Map(x => x.X, xColumnName).Access.BackingField();
                                     m.Map(x => x.Y, yColumnName).Access.BackingField();
                                     m.Map(x => x.Z, zColumnName).Access.BackingField();
                                 });
        }

        
    }
}