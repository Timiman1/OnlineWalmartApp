# OnlineWalmartApp

Grupparbete utfört utav Kamil, Jocke och Tim.

Kamil arbetade mest med user mikrotjänst.
Jocke arbetade mest med order mikrotjänst.
Tim arbetade mest med products mikrotjänst.

Mikrotjänsten auth körs på port : https://localhost:7087/
Mikrotjänsten orders körs på port : https://localhost:7028/
Mikrotjänsten products körs på port : https://localhost:7122/
Mikrotjänsten users körs på port : https://localhost:7022/
Gateway körs på port : https://localhost:7065/

Mikrotjänsterna (förutom gateway) har GET och POST endpoints.

Upstream sökvägen för samtliga mikrotjänster kan hittas i ocelote.json

Alla mikrotjänsterna är seedade med data, den enda mikrotjänsten som har authentication är orders där GET och POST är låst bakom JWT.

Användarnamnet för Auth enpoint är: order_user
Lösenord: 123

**OBS. Databaser kommer att skapas så fort du startar programmet med namn
WalmartProductDb -
WalmartUserDb -
WalmartOrderDb**

**Du behöver inte göra en database update, det sker automatiskt vid körning**
