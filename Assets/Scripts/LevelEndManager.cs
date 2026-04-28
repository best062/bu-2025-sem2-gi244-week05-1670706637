using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    [Header("ใส่ตัวเลขด่านปัจจุบันของฉากนี้ (เช่น ด่าน 1 ให้ใส่เลข 1)")]
    public int currentLevelIndex;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อศัตรูตายหมดเวฟสุดท้าย
    public void WinLevel()
    {
        // 1. ดึงข้อมูลด่านสูงสุดที่เคยปลดล็อคมาเช็คก่อน
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // 2. ถ้าด่านปัจจุบันที่เราเพิ่งชนะ มันเท่ากับหรือมากกว่าด่านที่ปลดล็อคอยู่ ให้ปลดล็อคด่านถัดไป
        if (currentLevelIndex >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex + 1); // บันทึกค่าเพื่อปลดล็อคด่านต่อไป 
            PlayerPrefs.Save();
        }

        // 3. โหลดกลับไปหน้าเลือกด่าน (ต้องพิมพ์ชื่อ Scene หน้าเลือกด่านของคุณให้เป๊ะๆ)
        SceneManager.LoadScene("LevelSelection");
    }
}

