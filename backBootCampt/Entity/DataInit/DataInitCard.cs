using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.DataInit
{
    public static class DataInitCard
    {
        public static void dataCard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
               new Card { id = 1, cardName = "Kawasaki Z900", cylinderCapacity = 948, weight = "190 kg", hP = 123.6m, finalSpeed = 246m, torque = 98.6m, nOclylinder = 4, isDeleted = false },
               new Card { id = 2, cardName = "Aprillia RSV4", cylinderCapacity = 1099, weight = "202 kg", hP = 137.2m, finalSpeed = 285m, torque = 100.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 3, cardName = "Yamaha MT-09", cylinderCapacity = 847, weight = "182 kg", hP = 121.2m, finalSpeed = 279m, torque = 93.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 4, cardName = "Kawasaki ZH2", cylinderCapacity = 997, weight = "192 kg", hP = 127.2m, finalSpeed = 290m, torque = 108.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 5, cardName = "Yamaha MT-10 SP", cylinderCapacity = 996, weight = "183 kg", hP = 123.7m, finalSpeed = 285.1m, torque = 102.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 6, cardName = "CF Motos SR R 675", cylinderCapacity = 675, weight = "184 kg", hP = 94.0m, finalSpeed = 238m, torque = 70m, nOclylinder = 4, isDeleted = false },
               new Card { id = 7, cardName = "Honda CBR 600", cylinderCapacity = 599, weight = "186 kg", hP = 120.5m, finalSpeed = 256m, torque = 63.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 8, cardName = "Honda CBR 600 RR", cylinderCapacity = 610, weight = "185 kg", hP = 121.3m, finalSpeed = 268.2m, torque = 74.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 9, cardName = "KTM Duke 1390", cylinderCapacity = 1390, weight = "209 kg", hP = 125.2m, finalSpeed = 290.3m, torque = 116.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 10, cardName = "Ducati Panigale V4", cylinderCapacity = 1103, weight = "198 kg", hP = 123.5m, finalSpeed = 299.2m, torque = 124.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 11, cardName = "Kawasaki Z1000", cylinderCapacity = 1043, weight = "208 kg", hP = 126.7m, finalSpeed = 250m, torque = 112m, nOclylinder = 4, isDeleted = false },
               new Card { id = 12, cardName = "Ducati Diavel", cylinderCapacity = 1158, weight = "214 kg", hP = 124.6m, finalSpeed = 275m, torque = 111.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 13, cardName = "Yamaha R6", cylinderCapacity = 601, weight = "184 kg", hP = 117m, finalSpeed = 269m, torque = 71m, nOclylinder = 4, isDeleted = false },
               new Card { id = 14, cardName = "CF Motos SR 450", cylinderCapacity = 450, weight = "168 kg", hP = 47m, finalSpeed = 193m, torque = 59m, nOclylinder = 4, isDeleted = false },
               new Card { id = 15, cardName = "BMW S1000R", cylinderCapacity = 1004, weight = "201 kg", hP = 127.9m, finalSpeed = 259m, torque = 103.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 16, cardName = "Honda CB 1000", cylinderCapacity = 992, weight = "202 kg", hP = 123.8m, finalSpeed = 234m, torque = 104.5m, nOclylinder = 4, isDeleted = false },
               new Card { id = 17, cardName = "Kawasaki ZX 6R", cylinderCapacity = 636, weight = "198 kg", hP = 120.1m, finalSpeed = 265m, torque = 78m, nOclylinder = 4, isDeleted = false },
               new Card { id = 18, cardName = "Kawasaki ZX 10 RR", cylinderCapacity = 1000, weight = "197 kg", hP = 123.9m, finalSpeed = 300m, torque = 114.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 19, cardName = "Aprillia RS 660", cylinderCapacity = 659, weight = "179 kg", hP = 110m, finalSpeed = 230m, torque = 77.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 20, cardName = "BMW GS1200", cylinderCapacity = 1170, weight = "214 kg", hP = 124.3m, finalSpeed = 260.4m, torque = 109.5m, nOclylinder = 4, isDeleted = false },
               new Card { id = 21, cardName = "Yamaha Tracer 900", cylinderCapacity = 890, weight = "219 kg", hP = 119m, finalSpeed = 238.1m, torque = 103m, nOclylinder = 4, isDeleted = false },
               new Card { id = 22, cardName = "Honda CBR 1000 RR", cylinderCapacity = 998, weight = "206 kg", hP = 125.7m, finalSpeed = 298.9m, torque = 113.9m, nOclylinder = 4, isDeleted = false },
               new Card { id = 23, cardName = "Suzuki GSX-R750", cylinderCapacity = 749, weight = "173 kg", hP = 118m, finalSpeed = 284.3m, torque = 126.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 24, cardName = "Yamaha R1M", cylinderCapacity = 995, weight = "207 kg", hP = 127.6m, finalSpeed = 298.5m, torque = 115.7m, nOclylinder = 4, isDeleted = false },
               new Card { id = 25, cardName = "Suzuki GSX-R1000R", cylinderCapacity = 1001, weight = "197 kg", hP = 127.7m, finalSpeed = 297.9m, torque = 112.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 26, cardName = "Ducati Streetfighter V4", cylinderCapacity = 1103, weight = "196.4 kg", hP = 129.4m, finalSpeed = 296.6m, torque = 113.6m, nOclylinder = 4, isDeleted = false },
               new Card { id = 27, cardName = "Suzuki GSX S 1000", cylinderCapacity = 1002, weight = "203.5 kg", hP = 122.6m, finalSpeed = 287.8m, torque = 106.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 28, cardName = "Suzuki Hayabusa", cylinderCapacity = 1340, weight = "219.4 kg", hP = 125.4m, finalSpeed = 301m, torque = 104.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 29, cardName = "KTM RC 8C", cylinderCapacity = 889, weight = "197.6 kg", hP = 125.3m, finalSpeed = 277.3m, torque = 102m, nOclylinder = 4, isDeleted = false },
               new Card { id = 30, cardName = "KTM Duke 390", cylinderCapacity = 399, weight = "169 kg", hP = 46m, finalSpeed = 223m, torque = 37m, nOclylinder = 4, isDeleted = false },
               new Card { id = 31, cardName = "BMW S1000 RR", cylinderCapacity = 1004, weight = "199.3 kg", hP = 129.3m, finalSpeed = 299.9m, torque = 114.8m, nOclylinder = 4, isDeleted = false },
               new Card { id = 32, cardName = "Kawasaki H2R", cylinderCapacity = 1007, weight = "198.8 kg", hP = 139m, finalSpeed = 300.1m, torque = 130m, nOclylinder = 4, isDeleted = false },
               new Card { id = 33, cardName = "Yamaha R7", cylinderCapacity = 689, weight = "187.5 kg", hP = 118.7m, finalSpeed = 179.8m, torque = 118.9m, nOclylinder = 4, isDeleted = false },
               new Card { id = 34, cardName = "Suzuki Katana 1000", cylinderCapacity = 1008, weight = "193.1 kg", hP = 126.4m, finalSpeed = 284.4m, torque = 116.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 35, cardName = "Ducati Super Sport 950S", cylinderCapacity = 937, weight = "187.1 kg", hP = 124.0m, finalSpeed = 296.7m, torque = 117.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 36, cardName = "Ducati Monster 937", cylinderCapacity = 937, weight = "195.1 kg", hP = 127.3m, finalSpeed = 282.2m, torque = 116.5m, nOclylinder = 4, isDeleted = false },
               new Card { id = 37, cardName = "Ducati 848 EVO", cylinderCapacity = 848, weight = "202.1 kg", hP = 123.3m, finalSpeed = 276.6m, torque = 119.6m, nOclylinder = 4, isDeleted = false },
               new Card { id = 38, cardName = "Triumph Daytona Moto2 765", cylinderCapacity = 765, weight = "203.5 kg", hP = 122.2m, finalSpeed = 288.2m, torque = 120.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 39, cardName = "Triumph Speed Triple 1200 RR", cylinderCapacity = 1190, weight = "210.4 kg", hP = 126.5m, finalSpeed = 280.2m, torque = 126.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 40, cardName = "MV Agusta F3 800", cylinderCapacity = 799, weight = "197.1 kg", hP = 122.1m, finalSpeed = 267.8m, torque = 122.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 41, cardName = "MV Agusta Brutale 1000 RR", cylinderCapacity = 1010, weight = "203.5 kg", hP = 128.6m, finalSpeed = 294.8m, torque = 126.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 42, cardName = "BMW R nineT Race", cylinderCapacity = 1000, weight = "192.9 kg", hP = 128.4m, finalSpeed = 291.7m, torque = 121.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 43, cardName = "CF Moto 800NK Sport", cylinderCapacity = 789, weight = "187.4 kg", hP = 124.1m, finalSpeed = 277.2m, torque = 112.1m, nOclylinder = 4, isDeleted = false },
               new Card { id = 44, cardName = "MV Agusta Superveloce 800", cylinderCapacity = 792, weight = "188.2 kg", hP = 121.7m, finalSpeed = 280.3m, torque = 102.9m, nOclylinder = 4, isDeleted = false },
               new Card { id = 45, cardName = "MV Agusta Turismo Veloce 800 Lusso SCS", cylinderCapacity = 788, weight = "192.1 kg", hP = 125.5m, finalSpeed = 284.5m, torque = 101.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 46, cardName = "Bimota Tesi H2", cylinderCapacity = 1014, weight = "188.8 kg", hP = 129.6m, finalSpeed = 292.1m, torque = 112.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 47, cardName = "Bimota KB4", cylinderCapacity = 1017, weight = "190.2 kg", hP = 126.9m, finalSpeed = 287.9m, torque = 112.9m, nOclylinder = 4, isDeleted = false },
               new Card { id = 48, cardName = "Kawasaki Ninja ZX-12R", cylinderCapacity = 1197, weight = "204.5 kg", hP = 127.1m, finalSpeed = 288.6m, torque = 119.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 49, cardName = "Kawasaki Ninja ZX-14R", cylinderCapacity = 1390, weight = "209.4 kg", hP = 130.2m, finalSpeed = 298.8m, torque = 128.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 50, cardName = "Yamaha FJR 1300", cylinderCapacity = 1270, weight = "201.9 kg", hP = 127.4m, finalSpeed = 287.2m, torque = 122.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 51, cardName = "Honda VFR800 Interceptor", cylinderCapacity = 869, weight = "173.5 kg", hP = 118.1m, finalSpeed = 282.8m, torque = 122.2m, nOclylinder = 4, isDeleted = false },
               new Card { id = 52, cardName = "Honda VFR 1200F", cylinderCapacity = 1193, weight = "202.8 kg", hP = 125.9m, finalSpeed = 293.2m, torque = 131.3m, nOclylinder = 4, isDeleted = false },
               new Card { id = 53, cardName = "Honda CBR1100XX Blackbird", cylinderCapacity = 1100, weight = "191.7 kg", hP = 124.8m, finalSpeed = 297.2m, torque = 114.4m, nOclylinder = 4, isDeleted = false },
               new Card { id = 54, cardName = "Suzuki TL1000R", cylinderCapacity = 1009, weight = "213.2 kg", hP = 132.8m, finalSpeed = 273.8m, torque = 111.7m, nOclylinder = 4, isDeleted = false },
               new Card { id = 55, cardName = "Triumph Daytona955i", cylinderCapacity = 954, weight = "219.4 kg", hP = 135.8m, finalSpeed = 301.6m, torque = 114.5m, nOclylinder = 4, isDeleted = false },
               new Card { id = 56, cardName = "Beneli TNT 1130R", cylinderCapacity = 1130, weight = "198.3 kg", hP = 135.3m, finalSpeed = 290.7m, torque = 110.9m, nOclylinder = 4, isDeleted = false }
            );
        }
    }
}
