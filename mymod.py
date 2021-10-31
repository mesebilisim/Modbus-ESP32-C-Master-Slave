from pymodbus.client.sync import ModbusTcpClient
import time

client = ModbusTcpClient('192.168.1.125')
# client = ModbusTcpClient('127.0.0.1')

val = True
for i in range(10):
    client.write_coil(100, val)
    print(i, val)
    val = not(val)
    time.sleep(1)


result = client.read_coils(100, 1)
# print(result.bits[0])
print(result)
client.close()

