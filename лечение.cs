//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace индивид
{
    using System;
    using System.Collections.Generic;
    
    public partial class лечение
    {
        public int код_лечения { get; set; }
        public int код_врача { get; set; }
        public System.DateTime дата_обращения { get; set; }
        public int код_диагноза { get; set; }
        public System.DateTime дата_выписки { get; set; }
        public int код_услуги { get; set; }
        public int код_пациента { get; set; }
    
        public virtual врачи врачи { get; set; }
        public virtual диагноз диагноз { get; set; }
        public virtual пациент пациент { get; set; }
        public virtual услуга услуга { get; set; }
    }
}
