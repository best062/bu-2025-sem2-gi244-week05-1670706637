using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    [Header("ใส่ปุ่มด่านทั้งหมดเรียงตามลำดับ (ด่าน 1, 2, 3...)")]
    public Button[] levelButtons;

    void Start()
    {
        // โหลดข้อมูลด่านที่ปลดล็อคแล้ว (ถ้าเพิ่งเล่นครั้งแรก ค่าเริ่มต้นคือด่าน 1)
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            // ถ้าด่านของปุ่มนี้ (i + 1) มากกว่าด่านที่ปลดล็อคแล้ว ให้ปิดไม่ให้กด
            if (i + 1 > unlockedLevel)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }
    }

    // เอาฟังก์ชันนี้ไปผูกกับ Event OnClick() ของปุ่มแต่ละปุ่มใน Inspector
    // และใส่ตัวเลขด่าน (1, 2, 3...) เข้าไปในช่องพารามิเตอร์
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
