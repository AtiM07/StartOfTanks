using System;

/// <summary>
/// Типы ячеек глобальной карты
/// </summary>
[Serializable]
public enum CellType
{
    /// <summary>
    /// Отсутствует
    /// </summary>
    None,
    
    /// <summary>
    /// Исследовано
    /// </summary>
    Active,
    
    /// <summary>
    /// Залежи ресурсов
    /// </summary>
    Diamond,
    
    /// <summary>
    /// Добыча ресурсов
    /// </summary>
    Factory,
    
    /// <summary>
    /// База
    /// </summary>
    Tower,
    
    /// <summary>
    /// Боевая операция
    /// </summary>
    Tank
}