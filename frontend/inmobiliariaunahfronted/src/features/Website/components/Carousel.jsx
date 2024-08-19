import { useState } from "react";
import { CarouselItem } from "./CarouselItem"
import { CarouselNext } from "./CarouselNext"
import { CarouselPrevious } from "./CarouselPrevious"

export const Carousel = ({imgs}) => {
    const [currentIndex, setCurrentIndex] = useState(0);
    const handlePreviousClick = () => {
        setCurrentIndex((prevIndex) => (prevIndex - 1 + imgs.length) % imgs.length);
      };
    
      const handleNextClick = () => {
        setCurrentIndex((prevIndex) => (prevIndex + 1) % imgs.length);
      };

  return (
    <span className="flex justify-between items-center">
    <CarouselPrevious onClick={handlePreviousClick} className="mr-0 "/>
      <div className="relative overflow-hidden w-full max-w-md h-64 mx-2  shadow-md">
      {imgs.map((src, index) => (
      <CarouselItem        
        key={index}
        src={src}
        isActive={index === currentIndex}
      />
    ))}
      </div>
    <CarouselNext onClick={handleNextClick} />
  </span>
  )
}
