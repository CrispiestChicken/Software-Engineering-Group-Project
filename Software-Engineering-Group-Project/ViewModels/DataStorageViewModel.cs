using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;

public class DataStorageViewModel: ObservableObject
{
    private GpDbContext _context;
    public IEntityType ModelRecord {get; set;}

    public DataStorageViewModel(GpDbContext context, IEntityType entity)
    {
        _context = context;
        ModelRecord = entity;
        ModelRecord.GetProperties();
    }

}