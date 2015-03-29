
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string nick);

string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string nick);


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);


AdministradorEN ReadOID (string nick);
}
}
