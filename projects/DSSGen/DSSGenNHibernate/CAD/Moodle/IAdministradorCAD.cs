
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email);

string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string email);


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);


AdministradorEN ReadOID (string email);


long ReadCantidad ();
}
}
