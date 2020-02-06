using System;

namespace NinjaDomain.Classes.Interfaces
{
    interface IModificationHistory
    {
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }
        bool isDirty { get; set; }
    }
}
