//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCarProp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        public int Id_Vehiculo { get; set; }
        public string Descripcion { get; set; }
        public string No_Chasis { get; set; }
        public Nullable<int> No_Motor { get; set; }
        public string No_Placa { get; set; }
        public Nullable<int> Tipo_Vehiculo { get; set; }
        public Nullable<int> Marca { get; set; }
        public Nullable<int> Modelo { get; set; }
        public Nullable<int> Tipo_Combustible { get; set; }
        public Nullable<int> Estado { get; set; }
    }
}
