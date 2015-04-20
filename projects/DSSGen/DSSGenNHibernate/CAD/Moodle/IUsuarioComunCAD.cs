
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IUsuarioComunCAD
{
UsuarioComunEN ReadOIDDefault (string email);

string New_ (UsuarioComunEN usuarioComun);

void Modify (UsuarioComunEN usuarioComun);


System.Collections.Generic.IList<UsuarioComunEN> ReadAll (int first, int size);


UsuarioComunEN ReadOID (string email);


long ReadCantidad ();


void Relationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje);
}
}
