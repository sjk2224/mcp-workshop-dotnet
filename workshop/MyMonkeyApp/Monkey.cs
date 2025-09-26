namespace MyMonkeyApp;

/// <summary>
/// 원숭이(Monkey) 정보를 나타내는 데이터 모델입니다.
/// </summary>
public class Monkey
{
    /// <summary>
    /// 원숭이 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 서식지 또는 위치
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// 상세 설명
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// 이미지 URL (선택)
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// 개체수
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// 위도 (선택)
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// 경도 (선택)
    /// </summary>
    public double? Longitude { get; set; }
}
