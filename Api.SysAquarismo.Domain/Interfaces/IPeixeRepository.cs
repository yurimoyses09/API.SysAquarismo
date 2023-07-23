﻿using Api.SysAquarismo.Domain.Models.Peixe;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IPeixeRepository
{
    Task InsertPeixe(Peixe peixe);
    Task DeletePeixe(Peixe peixe);
    Task GetPeixe();
    Task UpdatePeixe(Peixe peixe);
}