import { Message } from "./message";
import { User } from "./user";

export interface MessageGroup {
    id: number;
    name: string;
    users: User[];
    messages: Message[];
    newCount: number;
}