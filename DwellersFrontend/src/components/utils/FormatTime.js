export function formatDate(apiDate) {
  const date = new Date(apiDate);
  const options = { year: 'numeric', month: 'long', day: 'numeric' };
  const formattedDate = date.toLocaleDateString('sv-SE', options);
  const formattedTime = date.toLocaleTimeString('sv-SE', { hour: '2-digit', minute: '2-digit' });
  
  return `${formattedDate} kl. ${formattedTime}`;
}