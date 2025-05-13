using System;

namespace UserServie.Application.Common;

public abstract class CommonListFilterParameter
{
    public int PageNo { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
