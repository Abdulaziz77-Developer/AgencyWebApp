using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialRussianSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Москва (DME)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Истанбул (IST)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Душанбе (DYU)", "Активный", "Худжанд (LBD)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Дубай (DXB)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Ташкент (TAS)", "Активный", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Алматы (ALA)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Франкфурт (FRA)", "Задержан", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Дели (DEL)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Мюнхен (MUC)", "Активный", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Урумчи (URC)", "Запланирован", "Душанбе (DYU)" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "проспект Рудаки, 14", "Душанбе", "Таджикистан", "Роскошный 5-звездочный отель в самом сердце столицы, выполненный в традиционном таджикском стиле." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "проспект Исмоили Сомони, 26/1", "Душанбе", "Таджикистан", "Современный отель на берегу озера, идеально подходящий как для деловых поездок, так и для отдыха." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Нисора Мухаммада, 63", "Душанбе", "Таджикистан", "Бутик-отель, оформленный с использованием национальных тканей и располагающий прекрасным садом." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Камоли Худжанди, 22", "Худжанд", "Таджикистан", "Лучшие апартаменты в центре Худжанда с великолепным видом на реку Сырдарья." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Ленина, 15", "Худжанд", "Таджикистан", "Классический отель, расположенный рядом с историческим рынком Панджшанбе." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "поселок Калайхумб", "Дарвоз", "Таджикистан", "Ворота Памира. Роскошный комфорт в окружении величественных диких гор." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Ленина, 52", "Хорог", "Таджикистан", "Знаменитый памирский гостевой дом, известный своим гостеприимством и традиционной кухней." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "проспект Вахдат, 10", "Бохтар", "Таджикистан", "Комфортабельный отель в центре города, удобный для путешественников, изучающих Хатлонскую область." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Лоика Шерали, 3", "Душанбе", "Таджикистан", "Уютный и тихий бутик-отель, расположенный в элитном жилом районе столицы." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "ул. Айни, 48", "Душанбе", "Таджикистан", "Сервис премиум-класса вблизи аэропорта и центральной части Душанбе." });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Путешествие по Памирскому тракту изменило мою жизнь! Очень рекомендую всем любителям гор.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "Отель Dushanbe Serena — лучшее место для проживания. Очень профессиональный и вежливый персонал.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "Рейс из Москвы в Душанбе прошел вовремя, полет был очень комфортным. Спасибо!");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Text",
                value: "Озеро Искандеркуль просто захватывает дух. Наш гид рассказал много интересных легенд.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Text",
                value: "Отличный сервис в Hyatt Regency. Выбор блюд на завтрак был просто потрясающим.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "Text",
                value: "Крепость Хулбук — это настоящая скрытая жемчужина Хатлона. Обязательно к посещению для любителей истории.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "Text",
                value: "Руины Пенджикента впечатляют. Тур по Семи озерам немного утомительный, но он того стоит!");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "Text",
                value: "Перелет Somon Air в Худжанд был быстрым и спокойным. Никаких нареканий.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "Text",
                value: "Санаторий в Ходжа-Обигарм — уникальное место. Идеально подходит для оздоровления и релаксации.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "Text",
                value: "Классная поездка в Варзобское ущелье на выходные. Отличный способ сбежать от городской жары!");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Легендарное путешествие по высокогорным дорогам Памира с посещением города Хорог.", "ГБАО", "Приключение на Памирском тракте" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Исследуйте руины Саразма и невероятные Семь озер (Хафт-Кул).", "Согдийская область", "Древний Пенджикент и озера" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Посещение Национального музея, памятника Исмоили Сомони и колоритных местных базаров.", "Душанбе", "Выходные в Душанбе" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Посетите легендарное озеро Александра Македонского и знаменитый водопад «Фанская Ниагара».", "Фанские горы", "Побег к озеру Искандеркуль" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Отдых и лечение в знаменитом бальнеологическом санатории с уникальными термальными парами.", "Варзоб", "Оздоровление в Ходжа-Обигарм" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Жизнь кочевников, яки и фантастические «лунные» ландшафты высокогорья у границы с Китаем.", "Восточный Памир", "Мургаб: Крыша мира" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Исторический тур в крепость V века и прогулка по живописному берегу Сырдарьи.", "Согдийская область", "Тур в Худжандскую крепость" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Эко-тур в одну из самых красивых и отдаленных долин Таджикистана.", "Хатлон", "Природа Сари-Хосор" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Однодневная поездка в реконструированный дворец средневековых царей Хутталя.", "Хатлон", "История крепости Хулбук" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Самая популярная зона отдыха рядом с Душанбе: реки, горы и свежий воздух.", "РРП", "День в Варзобском ущелье" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$J4K9KM.WmiU9dnll1wfQP.vfReR76JPUgd8ostD2oOekk1/gNxPpG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Moscow (DME)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Istanbul (IST)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Dushanbe (DYU)", "Active", "Khujand (LBD)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Dubai (DXB)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Tashkent (TAS)", "Active", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Almaty (ALA)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Frankfurt (FRA)", "Delayed", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Delhi (DEL)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Munich (MUC)", "Active", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FromCity", "Status", "ToCity" },
                values: new object[] { "Urumqi (URC)", "Scheduled", "Dushanbe (DYU)" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "14 Rudaki Ave", "Dushanbe", "Tajikistan", "A luxury 5-star hotel in the heart of the capital with traditional Tajik architecture." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "26/1 Ismoili Somoni Ave", "Dushanbe", "Tajikistan", "Modern lakeside hotel perfect for business and leisure travelers." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "63 Nisor Muhammad St", "Dushanbe", "Tajikistan", "Boutique hotel featuring Tajik national fabrics and a beautiful garden." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "22 Kamoli Khujandi St", "Khujand", "Tajikistan", "The best apartments in Khujand city center with a river view." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "15 Lenin St", "Khujand", "Tajikistan", "Classic hotel located near the historical Panjshanbe Bazaar." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "Kalaikhumb Village", "Darvoz", "Tajikistan", "The gateway to the Pamirs. Luxury comfort in a remote mountain setting." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "52 Lenin St", "Khorog", "Tajikistan", "Famous Pamiri guesthouse known for its hospitality and traditional food." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "10 Vahdat Ave", "Bokhtar", "Tajikistan", "A comfortable central hotel for travelers exploring the Khatlon region." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "3 Loik Sherali St", "Dushanbe", "Tajikistan", "Cozy and quiet boutique hotel located in a premium residential area." });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "City", "Country", "Description" },
                values: new object[] { "48 Ayni St", "Dushanbe", "Tajikistan", "Premium hospitality close to the airport and Dushanbe city center." });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "The Pamir Highway tour was a life-changing experience! Highly recommend.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "Dushanbe Serena Hotel is the best place to stay. Very professional staff.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "The flight from Moscow to Dushanbe was on time and very comfortable.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Text",
                value: "Iskanderkul Lake is breathtaking. The tour guide was very knowledgeable.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Text",
                value: "Great service at Hyatt Regency. The breakfast selection was amazing.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "Text",
                value: "Hulbuk Fortress is a hidden gem in Khatlon. A must-visit for history lovers.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "Text",
                value: "Panjakent ruins are impressive. Seven Lakes tour was a bit tiring but worth it.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "Text",
                value: "Somon Air flight to Khujand was quick and smooth. No complaints.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "Text",
                value: "The sanatorium in Khoja-Obigarm is unique. Perfect for health and relaxation.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "Text",
                value: "Awesome day trip to Varzob Gorge. Great way to escape the city heat!");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "A legendary road trip through the high-altitude Pamir mountains and Khorog city.", "GBAO", "Pamir Highway Adventure" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Explore the ruins of Sarazm and the stunning Seven Lakes (Haft Kul).", "Sughd", "Ancient Panjakent & Lakes" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Visit the National Museum, Ismoili Somoni monument, and local bazaars.", "Dushanbe", "Dushanbe City Weekend" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Visit the lake of Alexander the Great and the famous 'Fan Niagara' waterfall.", "Fann Mountains", "Iskanderkul Lake Escape" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Relax at the famous Soviet-era balneological steam sanatorium.", "Varzob", "Khoja-Obigarm Wellness" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "High-altitude nomadic life, yaks, and moon-like landscapes near the Chinese border.", "East Pamir", "Murghab: Roof of the World" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Historical tour to the 5th-century fortress and the Syr Darya river.", "Sughd", "Khujand Fortress Tour" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "Eco-trip to one of the most beautiful and remote valleys in Tajikistan.", "Khatlon", "Sari Khosor Nature" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "A day trip to the reconstructed palace of the medieval Kings of Khuttal.", "Khatlon", "Hulbuk Fortress History" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Region", "Title" },
                values: new object[] { "The most popular recreation area near Dushanbe for rivers and hiking.", "RRP", "Varzob Gorge Day Trip" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");
        }
    }
}
