using QLKS.Controllers.Api.Pojo;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace QLKS.Controllers.Api
{
    public class BotChatController : ApiController
    {
        private dataQLKSEntities db = new dataQLKSEntities();

        // GET: api/BotChat
        public Object GetRooms(String startDate , String endDate, int typeRoom)
        {

            List<tblPhong> li = new List<tblPhong>();
            if (startDate.Equals("") || endDate.Equals(""))
            {
                li = db.tblPhongs.ToList();
            }
            else
            {
                startDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                endDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");

                DateTime dateS = (DateTime.Parse(startDate)).AddHours(12);
                DateTime dateE = (DateTime.Parse(endDate)).AddHours(12);
                li = db.tblPhongs.Where(t => !(db.tblPhieuDatPhongs.Where(m => (m.ma_tinh_trang == 1 || m.ma_tinh_trang == 2) 
                    && m.ngay_ra > dateS && m.ngay_vao < dateE) )
                    .Select(m => m.ma_phong).ToList().Contains(t.ma_phong)).Where(p=>p.loai_phong == typeRoom).ToList();
            }
            List<RoomPojo> roomReviews = new List<RoomPojo>();
            foreach (tblPhong room in li)
            {
                roomReviews.Add(new RoomPojo(room.ma_phong,room.so_phong, room.tblLoaiPhong.mo_ta));
            }
            var json = new
            {
                success = true,
                data = roomReviews
            };
            return json;
        }

        //Chưa update
        public Object GetRoomTypeImgByID(int id)
        {
            List<RoomTypePojo> roomTypeReviews = new List<RoomTypePojo>();

            tblLoaiPhong loaiPhong = db.tblLoaiPhongs.Find(id);
            
            List<String> imgs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(loaiPhong.anh);
            for (int i = 0; i < imgs.Count; i++)
            {
                imgs[i] = Url.Content(imgs[i]);
            }
            var json = new
            {
                success = true,
                data = imgs
            };
            return json;

        }
        public Object GetRoomTypeAll()
        {
            List<RoomTypePojo> roomTypeReviews = new List<RoomTypePojo>();

            List<tblLoaiPhong> tblLoaiPhongs = db.tblLoaiPhongs.ToList();
            foreach (tblLoaiPhong  loaiPhong in tblLoaiPhongs)
            {
                List<String> imgs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(loaiPhong.anh);
                for (int i = 0; i < imgs.Count; i++)
                {
                    imgs[i] = Url.Content(imgs[i]);
                }
                roomTypeReviews.Add(new RoomTypePojo(loaiPhong.loai_phong,loaiPhong.mo_ta,imgs.ToArray(),loaiPhong.gia));
            }
            var json = new
            {
                success = true,
                data = roomTypeReviews
            };
            return json;
        }

       

        public void PostBooking([FromBody]BookRoomPojo bookRoomPojo)
        {
            //add customer
            tblKhachHang khachHang = new tblKhachHang();
            khachHang.ma_kh = bookRoomPojo.MessID;
            khachHang.ho_ten = bookRoomPojo.FullName;
            khachHang.sdt = bookRoomPojo.PhoneNumber;
            khachHang.cmt = bookRoomPojo.IDCard;
            var kh = db.tblKhachHangs.Find(khachHang.ma_kh);

            if (kh == null)
            {
                db.tblKhachHangs.Add(khachHang);               
            }
            else
            {
                kh.ho_ten = bookRoomPojo.FullName;
                kh.sdt = bookRoomPojo.PhoneNumber;
            }
            db.SaveChanges();

            //add book room 
            tblPhieuDatPhong tblPhieuDatPhong = new tblPhieuDatPhong();
            tblPhieuDatPhong.ma_kh = kh.ma_kh;
            tblPhieuDatPhong.ngay_dat = DateTime.Now;
            tblPhieuDatPhong.ngay_vao = DateTime.Parse(DateTime.ParseExact(bookRoomPojo.startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd"));
            tblPhieuDatPhong.ngay_ra = DateTime.Parse(DateTime.ParseExact(bookRoomPojo.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd"));
            tblPhieuDatPhong.ma_phong = bookRoomPojo.roomID;
            tblPhieuDatPhong.ma_tinh_trang = bookRoomPojo.status;
            db.tblPhieuDatPhongs.Add(tblPhieuDatPhong);
            db.SaveChanges();
        }

        public void PostSendMess([FromBody] SendMessPoro sendMessPoro)
        {
            //add customer
            tblKhachHang khachHang = new tblKhachHang();
            khachHang.ma_kh = sendMessPoro.MessID;
            khachHang.ho_ten = sendMessPoro.FullName;
            khachHang.sdt = sendMessPoro.PhoneNumber;
            var kh = db.tblKhachHangs.Find(khachHang.ma_kh);

            if (kh == null)
            {
                db.tblKhachHangs.Add(khachHang);
            }
            else
            {
                kh.ho_ten = sendMessPoro.FullName;
                kh.sdt = sendMessPoro.PhoneNumber;
            }
            db.SaveChanges();

            tblTinNhan tinNhan = new tblTinNhan();
            tinNhan.ma_kh = sendMessPoro.MessID;
            tinNhan.mail = sendMessPoro.Email;
            tinNhan.ho_ten = sendMessPoro.FullName;
            tinNhan.ngay_gui = DateTime.Now;
            tinNhan.noi_dung = sendMessPoro.Content;
            db.tblTinNhans.Add(tinNhan);
            db.SaveChanges();
        }




        
    }
}
