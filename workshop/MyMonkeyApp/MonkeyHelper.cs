using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();
    private static int randomPickCount = 0;
    private static readonly HttpClient httpClient = new();
    private static bool isLoaded = false;

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 불러옵니다.
    /// </summary>
    public static async Task LoadMonkeysAsync()
    {
        if (isLoaded) return;
        // MCP 서버의 엔드포인트 URL (예시)
        var url = "https://monkeymcp.azurewebsites.net/api/monkeys";
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<List<Monkey>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (data != null)
        {
            monkeys = data;
            isLoaded = true;
        }
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 무작위로 원숭이를 반환하고, 호출 횟수를 기록합니다.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        var random = new Random();
        randomPickCount++;
        return monkeys[random.Next(monkeys.Count)];
    }

    /// <summary>
    /// 무작위 선택이 호출된 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount() => randomPickCount;
}
