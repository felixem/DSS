
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (int id);

int New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (int id);


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);


AdministradorEN ReadOID (int id);



DSSGenNHibernate.EN.Moodle.AdministradorEN ReadNick (string nick);
}
}
