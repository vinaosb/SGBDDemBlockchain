//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v1.3.0.6
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharedLibrary
{
   public partial class MantenedoraDaEscola
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected MantenedoraDaEscola()
      {
         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="empresa"></param>
      /// <param name="sindicato"></param>
      /// <param name="sistema_s_sesi"></param>
      /// <param name="senai"></param>
      /// <param name="sesc"></param>
      /// <param name="_escola0"></param>
      public MantenedoraDaEscola(bool empresa, bool sindicato, bool sistema_s_sesi, bool senai, bool sesc, global::SharedLibrary.Escola _escola0)
      {
         this.Empresa = empresa;
         this.Sindicato = sindicato;
         this.Sistema_S_Sesi = sistema_s_sesi;
         this.Senai = senai;
         this.Sesc = sesc;
         if (_escola0 == null) throw new ArgumentNullException(nameof(_escola0));
         _escola0.MantenedoraDaEscola = this;

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="empresa"></param>
      /// <param name="sindicato"></param>
      /// <param name="sistema_s_sesi"></param>
      /// <param name="senai"></param>
      /// <param name="sesc"></param>
      /// <param name="_escola0"></param>
      public static MantenedoraDaEscola Create(bool empresa, bool sindicato, bool sistema_s_sesi, bool senai, bool sesc, global::SharedLibrary.Escola _escola0)
      {
         return new MantenedoraDaEscola(empresa, sindicato, sistema_s_sesi, senai, sesc, _escola0);
      }

      /*************************************************************************
       * Persistent properties
       *************************************************************************/

      /// <summary>
      /// Identity, Required, Indexed
      /// </summary>
      [Key]
      [Required]
      public int Cod_Entidade { get; private set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public bool Empresa { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public bool Sindicato { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public bool Sistema_S_Sesi { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public bool Senai { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public bool Sesc { get; set; }

      /*************************************************************************
       * Persistent navigation properties
       *************************************************************************/

   }
}

