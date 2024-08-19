import { useSpring, animated } from '@react-spring/web';

export const CarouselItem = ({ src, isActive }) => {

  const props = useSpring({
    opacity: isActive ? 1 : 0,
    transform: isActive ? 'translateX(0)' : 'translateX(100%)',
    config: { tension: 280, friction: 60 },
  });
  return (
    <animated.div
      style={{
        ...props,
        borderRadius:'15px',
        backgroundImage: `url(${src})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        width: '100%',
        height: '100%',
        position: 'absolute',
        top: 0,
        left: 0,
        zIndex: 1, // Asegúrate de que el z-index sea menor que el del navbar
      }}
    />
  );
};