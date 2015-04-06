
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


long ReadCantidad ();



DSSGenNHibernate.EN.Moodle.UsuarioEN ReadDni (string dni);
}
}
