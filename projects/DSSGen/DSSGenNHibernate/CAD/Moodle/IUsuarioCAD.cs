
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email);

string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email);


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


UsuarioEN ReadOID (string email);


void Relationer_mensajes (string p_usuario, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_mensajes (string p_usuario, System.Collections.Generic.IList<int> p_mensaje);


DSSGenNHibernate.EN.Moodle.UsuarioEN ReadDni (string dni);
}
}
