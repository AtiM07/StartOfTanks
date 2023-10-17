using System;

/// <summary>
/// ���� ����� ���������� �����
/// </summary>
[Serializable]
public enum CellType
{
    /// <summary>
    /// �����������
    /// </summary>
    None,
    
    /// <summary>
    /// �����������
    /// </summary>
    Active,
    
    /// <summary>
    /// ������ ��������
    /// </summary>
    Diamond,
    
    /// <summary>
    /// ������ ��������
    /// </summary>
    Factory,
    
    /// <summary>
    /// ����
    /// </summary>
    Tower,
    
    /// <summary>
    /// ������ ��������
    /// </summary>
    Tank
}