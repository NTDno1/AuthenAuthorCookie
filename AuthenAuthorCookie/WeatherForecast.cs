namespace AuthenAuthorCookie
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}

//public async Task CreateObject<T>(T thamso) where T : class
//{
//    try
//    {
//        if (thamso != null)
//        {
//            _db.Set<T>().Add(thamso);
//        }
//        await _db.SaveChangesAsync();
//    }
//    catch (Exception ex)
//    {
//        throw new Exception($"Error creating object: {ex.Message}", ex);
//    }
//}
//public async Task UpdateObject<T>(T thamso) where T : class
//{
//    try
//    {
//        if (thamso != null)
//        {
//            var entry = _db.Entry(thamso);
//            if (entry.State == System.Data.Entity.EntityState.Detached)
//            {
//                _db.Set<T>().Attach(thamso);
//            }
//            entry.State = System.Data.Entity.EntityState.Modified;
//        }
//        await _db.SaveChangesAsync();
//    }
//    catch (Exception ex)
//    {
//        throw new Exception($"Error updating object: {ex.Message}", ex);
//    }
//}

//public async Task RemoveObject<T>(T thamso) where T : class
//{
//    try
//    {
//        if (thamso != null)
//        {
//            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
//            {
//                foreach (var item in (IEnumerable<object>)thamso)
//                {
//                    _db.Set(item.GetType()).Remove(item);
//                }
//            }
//            else
//            {
//                _db.Set<T>().Remove(thamso);
//            }
//        }
//        await _db.SaveChangesAsync();
//    }
//    catch (Exception ex)
//    {
//        throw new Exception($"Error removing object: {ex.Message}", ex);
//    }
//}