
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id);

int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id);


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


UsuarioEN ReadOID (int id);


void Relationer_mensajes (int p_usuario, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_mensajes (int p_usuario, System.Collections.Generic.IList<int> p_mensaje);
}
}
