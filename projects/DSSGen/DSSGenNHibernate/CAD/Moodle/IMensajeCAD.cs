
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id);

int New_ (MensajeEN mensaje);

void Modify (MensajeEN mensaje);


void Destroy (int id);


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);


MensajeEN ReadOID (int id);


long ReadCantidad ();


void Relationer_tutoria (int p_mensaje, int p_tutoria);

void Relationer_usuario (int p_mensaje, string p_usuariocomun);

void Unrelationer_tutoria (int p_mensaje, int p_tutoria);

void Unrelationer_usuario (int p_mensaje, string p_usuariocomun);
}
}
