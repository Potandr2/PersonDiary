export class CommonUtils {
  static correctDate2UTC(date: Date) {
    if (typeof date === "string") date = new Date(date);
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()));
  }
  static getErorrMessagesText(messages: any) {
    let result: string="";
    messages.filter(m => m.type == 1).forEach(m => result += m.text);
    return result;
  }
}
