//===================================================
//Author      : DRB
//CreateTime  ：11/6/2017 2:21:52 PM
//Description ：
//===================================================
using System.Collections.Generic;

namespace guandan.proto {

public class GD_ENTER_ROOM_GET { 

	public const int CODE = 801002; 

	private byte[] __flag = new byte[1]; 

	private int _roomId; 

	public int roomId { 
		set { 
			if(!this.hasRoomId()) {
	    		this.__flag[0] = (byte) (this.__flag[0] | 1);
			}
			this._roomId = value;
		} 
		get { 
			return this._roomId;
		} 
	} 

	public static GD_ENTER_ROOM_GET newBuilder() { 
		return new GD_ENTER_ROOM_GET(); 
	} 

	public static GD_ENTER_ROOM_GET decode(byte[] data) { 
		GD_ENTER_ROOM_GET proto = newBuilder();
		proto.build(data);
		return proto; 
	} 

	public byte[] encode() { 

		ByteBuffer[] bytes = new ByteBuffer[1]; 

		int total = 0;
		if(this.hasRoomId()) {
			bytes[0] = ByteBuffer.allocate(4);
			bytes[0].putInt(this.roomId);
			total += bytes[0].limit();
		}

	
		ByteBuffer buf = ByteBuffer.allocate(1 + total);
	
		buf.put(this.__flag);
	
		for (int i = 0; i < bytes.Length; i++) {
			if (bytes[i] != null) {
			   buf.put(bytes[i].array());
		    }
		}
	
		return buf.array();

	}

	public void build(byte[] data) { 
		  
		ByteBuffer buf = ByteBuffer.wrap(data);
		  
		for (int i = 0; i < this.__flag.Length; i++) {
		    this.__flag[i] = buf.get();
		}
		  
		if(this.hasRoomId()) {
			this.roomId = buf.getInt();
		}

	} 

	public bool hasRoomId() {
		return (this.__flag[0] & 1) != 0;
	}

}
}

