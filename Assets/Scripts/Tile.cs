using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{

    public bool isEmpty;
    public int row;
    public int col;

    public int gCost;
    public int hCost;
    public Tile parent;


    void Start()
    {
        isEmpty = true;
    }

    /// Eğer diğer değişkenler kuruluma müsaitse, kurulum sürecini başlatır.
    private void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            PlaceOnTile();
        }
    }

    /// Binaların kurulumu için gereken pozisyonu döndürür. 0.16 pixel -x ve -y koordinatlarına itilir ki bina yerine tam otursun.
    public Vector3 GetPositionForConstruction()
    {
        return new Vector3(transform.position.x - 0.16f, transform.position.y - 0.16f,transform.position.z);
    }
    ///  Güzergah için gereken pozisyonu döndürür.
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void PlaceOnTile()
    {
        GameManager.gM.PlaceObjectAndFillTile(GetPositionForConstruction(),row,col);
    }
    /// Bina inşaa edilen (üniteler için bunu çalıştırmıyor) tileların isEmpty parametresini ayarlar.
    public void MakeCellFilled()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 0);
        isEmpty = false;
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
