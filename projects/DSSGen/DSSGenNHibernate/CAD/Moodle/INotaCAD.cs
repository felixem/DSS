
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface INotaCAD
{
NotaEN ReadOIDDefault (int id);

int New_ (NotaEN nota);

void Modify (NotaEN nota);


void Destroy (int id);


System.Collections.Generic.IList<NotaEN> ReadAll (int first, int size);


NotaEN ReadOID (int id);


void Relationer_expedientes (int p_nota, System.Collections.Generic.IList<int> p_expedienteasignatura);

void Unrelationer_expedientes (int p_nota, System.Collections.Generic.IList<int> p_expedienteasignatura);
}
}
