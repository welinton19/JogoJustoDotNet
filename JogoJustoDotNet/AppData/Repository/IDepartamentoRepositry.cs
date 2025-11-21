using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public interface IDepartamentoRepositry
{
    IEnumerable<DepartamentoModel> GetAllDepartamentos();
    DepartamentoModel GetDepartamentoById(int id);
    void CreateDepartamento(DepartamentoModel departamento);
    void UpdateDepartamento(DepartamentoModel departamento);
    void DeleteDepartamentoModel(int id);
    void DeleteDepartamentoModel(DepartamentoModel departamento);
}
